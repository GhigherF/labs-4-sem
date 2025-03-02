#include "Combi.h"
#include <vector>
#include <stdexcept>

namespace combi
{
    accomodation::accomodation(short n, short m)
    {
        if (n < 0 || m < 0 || n < m) {
            throw std::invalid_argument("Invalid values for n and m");
        }

        this->n = n;
        this->m = m;
        this->cgen = new xcombination(n, m);
        this->pgen = new permutation(m);
        this->sset = new short[m]; // ����� �������� �� std::vector<short>
        this->reset();
    }

    void accomodation::reset()
    {
        this->na = 0;
        this->cgen->reset();
        this->pgen->reset();
        this->cgen->getfirst();
    }

    short accomodation::getfirst()
    {
        short rc = (this->n >= this->m) ? this->m : -1;
        if (rc > 0)
        {
            for (int i = 0; i < this->m; i++) // �������� �� i < this->m
            {
                this->sset[i] = this->cgen->sset[this->pgen->ntx(i)];
            }
        }
        return rc;
    }

    short accomodation::getnext()
    {
        short rc;
        this->na++;
        if ((this->pgen->getnext()) > 0)
        {
            rc = this->getfirst();
        }
        else if ((rc = this->cgen->getnext()) > 0)
        {
            this->pgen->reset();
            rc = this->getfirst();
        }
        return rc;
    }

    short accomodation::ntx(short i)
    {
        return this->sset[i];
    }

    unsigned __int64 fact(unsigned __int64 x)
    {
        return (x == 0) ? 1 : (x * fact(x - 1));
    }

    unsigned __int64 accomodation::count() const
    {
        return (this->n >= this->m) ?
            fact(this->n) / fact(this->n - this->m) : 0;
    }
}